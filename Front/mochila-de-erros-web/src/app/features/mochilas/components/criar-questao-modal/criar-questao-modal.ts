import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

interface Alternativa {
  letra: string;
  texto: string;
}

@Component({
  selector: 'app-criar-questao-modal',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './criar-questao-modal.html',
  styleUrl: './criar-questao-modal.scss',
})
export class CriarQuestaoModal {
  @Output() salvar = new EventEmitter<any>();
  @Output() fechar = new EventEmitter<void>();

  enunciado: string = '';

  alternativas: Alternativa[] = [
    { letra: 'A', texto: '' },
    { letra: 'B', texto: '' },
    { letra: 'C', texto: '' },
    { letra: 'D', texto: '' },
    { letra: 'E', texto: '' },
  ];

  alternativaCorreta: string = '';

  salvarQuestao() {
    if (!this.enunciado.trim()) {
      alert('Digite o enunciado.');
      return;
    }

    if (!this.alternativaCorreta) {
      alert('Selecione a alternativa correta.');
      return;
    }

    const questao = {
      enunciado: this.enunciado,
      alternativas: this.alternativas,
      correta: this.alternativaCorreta,
      explicacao: this.explicacao,
      origem: this.origem,
      imagem: this.imagemBase64,
      acertosConsecutivos: 0
    };

    this.salvar.emit(questao);
  }
  explicacao: string = '';
  origem: string = '';
  imagemBase64: string | null = null;

  onFileSelected(event: any) {
    const file = event.target.files[0];
    if (!file) return;

    const reader = new FileReader();
    reader.onload = () => {
      this.imagemBase64 = reader.result as string;
    };
    reader.readAsDataURL(file);
  }

}
