import { Component } from '@angular/core';
import { EventEmitter } from '@angular/core';
import { Output } from '@angular/core';
import { MochilasService } from '../../services/mochilas.service';
import { CommonModule } from '@angular/common';
import { FormsModule  } from '@angular/forms';

@Component({
  selector: 'app-criar-mochila-modal',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './criar-mochila-modal.html',
  styleUrls: ['./criar-mochila-modal.scss']
})
export class CriarMochilaModal {
  @Output() fechar = new EventEmitter<void>();
  @Output() criada = new EventEmitter<void>();

  novaTag = '';

  form = {
    nome: '',
    descricao: '',
    cor: '#7c3aed',
    frequenciaRevisao: 2,
    tags: [] as string[]
  };

  cores = ['#7c3aed', '#10b981', '#f59e0b', '#ec4899', '#3b82f6'];

  constructor(private mochilasService: MochilasService) {}

  adicionarTag() {
    if (this.novaTag && !this.form.tags.includes(this.novaTag)) {
      this.form.tags.push(this.novaTag);
      this.novaTag = '';
    }
  }

  removerTag(tag: string){
    this.form.tags = this.form.tags.filter(t => t !== tag);
  }

  criar() {
    console.log('Tags no submit:', this.form.tags);

    const payload = {
      userId: '3fa85f64-5717-4562-b3fc-2c963f66afa6',
      nome: this.form.nome,
      descricao: this.form.descricao,
      cor: this.form.cor,
      frequenciaRevisao: this.form.frequenciaRevisao,
      tags: [...this.form.tags]
    };

    this.mochilasService.create(payload).subscribe(() => {
      this.criada.emit();
    });
  }
}