.data
firstLoopCounter QWORD 0			;licznik dla pixeli
secondLoopCounter QWORD 0			;licznik dla winiety
allPixels QWORD 0					;wska�nik na wszystkie pixele podlegaj�ce winiecie, oczytywane z rcx
vignette QWORD 0					;wska�nik na tablice z warto�ciami winiety dla pixeli, odczytywane z rdx
len QWORD 0							;ilo�� pixeli podlegaj�cych winiecie, odczytwane z r8
finalPixels QWORD 0					;wska�nik na zwinietowanie pixele, oczytywane z r9

.code
vignetting PROC
									;zachowanie rejestr�w na stosie
	push rsi
	push rbx
	push r11

prepareData:
	mov allPixels, rcx				;piewszy arguemnt
	mov vignette, rdx				;drugi arguemnt		
	mov len, r8						;trzeci arguemnt	
	mov finalPixels, r9				;czwarty arguemnt
	mov firstLoopCounter, 0			;ustawienie p�tli na 0
	mov secondLoopCounter, 0		;ustawienie p�tli na 0
	xor rcx, rcx				    ;czyszczenie rcx
	mov rcx, len					;przypisanie ilo�ci pixeli do rcx
	mov rsi, allPixels				;wska�nik na pixele do rsi
	mov rbx, finalPixels			;wska�nik na finalne pixele do rbx
	mov r8, firstLoopCounter		;licznik pierwszej p�tli do r8
	mov rdx, vignette				;wska�nik na viniety do rdx
	mov r9, secondLoopCounter		;licznik drugiej p�tli do r9

mainLoop:
	 xor rax, rax					;czyszczenie rax
	 mov rax, [rsi+r8*4]			;pozycja x pixela do rax
	 mov [rbx+r8*4], rax			;pozycja x pixela do pozycji x finalnego pixela
	 inc r8							;inkrementacja licznika pixeli
	 mov rax, [rsi+r8*4]			;pozycja y pixela do rax
	 mov [rbx+r8*4], rax			;pozycja y pixela do pozycji y finalnego pixela
	 inc r8							;inkrementacja licznika pixeli
	 xor rax, rax					;czyszczenie rax
	 mov rax, [rdx+r9*4]			;warto�ci winiety dla tego pixela do rax
	 cmp eax, 0						;je�li jest r�wna 0 to czarny pixel
	 je blackPixel
	 xor rax, rax					;czyszczenie rax
	 mov rax, [rdx+r9*4]			;warto�ci winiety dla tego pixela do rax
	 cmp eax, 1						;je�li r�wna jeden to przepisujemy colory pixela
	 je samePixel
	 jmp differentPixel				;je�li wcze�niej nie wykona�o skoku to wyliczamy colory

finishSingleIteration:	
	 inc r9							;inkrementacja licznika viniety
	 sub rcx, 1						;odj�cie 1 od rcx
     jnz mainLoop					;r�ne od 0, wracamy do p�tli
	 jmp returnValue				;r�wne 0, ko�czymy procedur�

blackPixel:
	 mov rax, 0						;0 do rax
	 mov [rbx+r8*4], rax			;0 do coloru R finalnego pixela
	 inc r8							;inkrementacja licznika pixeli
	 mov [rbx+r8*4], rax			;0 do coloru B finalnego pixela
	 inc r8							;inkrementacja licznika pixeli
	 mov [rbx+r8*4], rax			;0 do coloru B finalnego pixela
	 inc r8							;inkrementacja licznika pixeli
	 jmp finishSingleIteration		;powr�t do ko�ca g��wnej p�tli

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
	jmp finishSingleIteration		;powr�t do ko�ca g��wnej p�tli

differentPixel:
	pxor xmm1, xmm1					;czyszczenie xmm1, instrukacja wektorowa
	pxor xmm2, xmm2					;czyszczenie xmm2, instrukacja wektorowa
	mov rax, [rdx+r9*4]				;warto�� winiety dla aktualnego pixela do rax
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
	jmp finishSingleIteration		;powr�t do ko�ca p�tli

returnValue:
	mov rax, finalPixels			;wska�nik na finalne pixele do rax

									;przywr�cenie rejest�w
	pop rsi
	pop rbx
	pop r11
    ret									

vignetting ENDP            
end