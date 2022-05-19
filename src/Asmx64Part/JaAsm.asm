.data
firstLoopCounter QWORD 0			;licznik dla pixeli
secondLoopCounter QWORD 0			;licznik dla winiety
allPixels QWORD 0					;wskaŸnik na wszystkie pixele podlegaj¹ce winiecie, oczytywane z rcx
vignette QWORD 0					;wskaŸnik na tablice z wartoœciami winiety dla pixeli, odczytywane z rdx
len QWORD 0							;iloœæ pixeli podlegaj¹cych winiecie, odczytwane z r8
finalPixels QWORD 0					;wskaŸnik na zwinietowanie pixele, oczytywane z r9

.code
vignetting PROC
									;zachowanie rejestrów na stosie
	push rsi
	push rbx
	push r11

prepareData:
	mov allPixels, rcx				;piewszy arguemnt
	mov vignette, rdx				;drugi arguemnt		
	mov len, r8						;trzeci arguemnt	
	mov finalPixels, r9				;czwarty arguemnt
	mov firstLoopCounter, 0			;ustawienie pêtli na 0
	mov secondLoopCounter, 0		;ustawienie pêtli na 0
	xor rcx, rcx				    ;czyszczenie rcx
	mov rcx, len					;przypisanie iloœci pixeli do rcx
	mov rsi, allPixels				;wskaŸnik na pixele do rsi
	mov rbx, finalPixels			;wskaŸnik na finalne pixele do rbx
	mov r8, firstLoopCounter		;licznik pierwszej pêtli do r8
	mov rdx, vignette				;wskaŸnik na viniety do rdx
	mov r9, secondLoopCounter		;licznik drugiej pêtli do r9

mainLoop:
	 xor rax, rax					;czyszczenie rax
	 mov rax, [rsi+r8*4]			;pozycja x pixela do rax
	 mov [rbx+r8*4], rax			;pozycja x pixela do pozycji x finalnego pixela
	 inc r8							;inkrementacja licznika pixeli
	 mov rax, [rsi+r8*4]			;pozycja y pixela do rax
	 mov [rbx+r8*4], rax			;pozycja y pixela do pozycji y finalnego pixela
	 inc r8							;inkrementacja licznika pixeli
	 xor rax, rax					;czyszczenie rax
	 mov rax, [rdx+r9*4]			;wartoœci winiety dla tego pixela do rax
	 cmp eax, 0						;jeœli jest równa 0 to czarny pixel
	 je blackPixel
	 xor rax, rax					;czyszczenie rax
	 mov rax, [rdx+r9*4]			;wartoœci winiety dla tego pixela do rax
	 cmp eax, 1						;jeœli równa jeden to przepisujemy colory pixela
	 je samePixel
	 jmp differentPixel				;jeœli wczeœniej nie wykona³o skoku to wyliczamy colory

finishSingleIteration:	
	 inc r9							;inkrementacja licznika viniety
	 sub rcx, 1						;odjêcie 1 od rcx
     jnz mainLoop					;ró¿ne od 0, wracamy do pêtli
	 jmp returnValue				;równe 0, koñczymy procedurê

blackPixel:
	 mov rax, 0						;0 do rax
	 mov [rbx+r8*4], rax			;0 do coloru R finalnego pixela
	 inc r8							;inkrementacja licznika pixeli
	 mov [rbx+r8*4], rax			;0 do coloru B finalnego pixela
	 inc r8							;inkrementacja licznika pixeli
	 mov [rbx+r8*4], rax			;0 do coloru B finalnego pixela
	 inc r8							;inkrementacja licznika pixeli
	 jmp finishSingleIteration		;powrót do koñca g³ównej pêtli

samePixel:
	mov rax, [rsi+r8*4]				;color R pixela do rax
	mov [rbx+r8*4], rax				;color R pixela do coloru R finalnego pixela
	inc r8							;inkrementacja licznika pixeli
	mov rax, [rsi+r8*4]				;color G pixela do rax
	mov [rbx+r8*4], rax				;color G pixela do coloru G finalnego pixela
	inc r8							;inkrementacja licznika pixeli
	mov rax, [rsi+r8*4]				;color B pixela do rax
	mov [rbx+r8*4], rax				;color B pixela do coloru B finalnego pixela
	inc r8							;inkrementacja licznika pixeli
	jmp finishSingleIteration		;powrót do koñca g³ównej pêtli

differentPixel:
	pxor xmm1, xmm1					;czyszczenie xmm1, instrukacja wektorowa
	pxor xmm2, xmm2					;czyszczenie xmm2, instrukacja wektorowa
	mov rax, [rdx+r9*4]				;wartoœæ winiety dla aktualnego pixela do rax
	cvtsi2ss xmm2, eax				;konwersja na float do xmm2, instrukacja wektorowa
	mov rax, [rsi+r8*4]				;color R pixla do rax
	inc r8							;inkrementacja licznika pixeli
	add rax, [rsi+r8*4]				;dodaj color G pixla do rax	
	inc r8							;inkrementacja licznika pixeli
	add rax, [rsi+r8*4]				;dodaj color B pixla do rax
	cvtsi2ss xmm1, eax				;konwesja na float do xmm1, instrukacja wektorowa
	divss xmm1, xmm2				;xmm1/xmm2 wynik do xmm1, instrukacja wektorowa
	cvtss2si eax, xmm1				;konwesja na inta do eax, instrukacja wektorowa
	dec r8							;dekrementacja licznika pixeli
	dec r8							;dekrementacja licznika pixeli
	mov [rbx+r8*4], rax				;przepisanie wyniku do coloru R finalnego pixela
	inc r8							;inkrementacja licznika pixeli
	mov [rbx+r8*4], rax				;przepisanie wyniku do coloru R finalnego pixela
	inc r8							;inkrementacja licznika pixeli
	mov [rbx+r8*4], rax				;przepisanie wyniku do coloru R finalnego pixela
	inc r8							;inkrementacja licznika pixeli
	jmp finishSingleIteration		;powrót do koñca pêtli

returnValue:
	mov rax, finalPixels			;wskaŸnik na finalne pixele do rax

									;przywrócenie rejestów
	pop rsi
	pop rbx
	pop r11
    ret									

vignetting ENDP            
end