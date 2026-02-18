import { Component } from '@angular/core';
import { MochilaCard } from '../../../models/mochilas-card.model';
import { MochilasService } from '../../../services/mochilas.service';
import { MochilaCardComponent } from '../../../components/mochila-card/mochila-card';
import { CommonModule } from '@angular/common';
import { CriarMochilaModal } from "../../../components/criar-mochila-modal/criar-mochila-modal";

@Component({
  selector: 'app-mochilas-page',
  imports: [MochilaCardComponent,
    CommonModule, CriarMochilaModal],
  templateUrl: './mochilas-page.html',
  styleUrl: './mochilas-page.scss',
})
export class MochilasPage {
    mochilas: MochilaCard[] = [];
    carregando = true;

    modalAberto = false;

    // temporário, depois substituir por ID do usuário logado
    private userId = '3fa85f64-5717-4562-b3fc-2c963f66afa6';

    constructor(private mochilasService: MochilasService) {}

    carregarMochilas(){
      this.mochilasService.getCards(this.userId).subscribe({
        next: (data) => {
          this.mochilas = data;
          this.carregando = false;
        },
        error: () => {
          this.carregando = false;
        }
      });
    }

    ngOnInit(): void {
      this.carregarMochilas();
    }

    abrirModal() {
      this.modalAberto = true;
    }

    fecharModal() {
      this.modalAberto = false;
    }

    onMochilaCriada() {
      this.fecharModal();
      this.carregarMochilas();
    }
}
