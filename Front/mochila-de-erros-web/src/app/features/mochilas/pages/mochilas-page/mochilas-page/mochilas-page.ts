import { Component } from '@angular/core';
import { MochilaCard } from '../../../models/mochilas-card.model';
import { MochilasService } from '../../../services/mochilas.service';
import { MochilaCardComponent } from '../../../components/mochila-card/mochila-card';
import { CommonModule } from '@angular/common';
import { Rodape } from '../../../components/rodape/rodape';
import { CriarMochilaModal } from '../../../components/criar-mochila-modal/criar-mochila-modal';
import { FormsModule } from '@angular/forms';
import { UsoPlano } from '../../../models/uso-plano.model';
import { UsuarioService } from '../../../services/usuario.service';

@Component({
  selector: 'app-mochilas-page',
  imports: [
    MochilaCardComponent,
    CommonModule, 
    Rodape, 
    CriarMochilaModal, 
    FormsModule
  ],
  templateUrl: './mochilas-page.html',
  styleUrl: './mochilas-page.scss',
})
export class MochilasPage {
    mochilas: MochilaCard[] = [];
    carregando = true;

    modalAberto = false;

    usoPlano: UsoPlano | null = null;
    planoLabel = 'gratuito';

    // temporário, depois substituir por ID do usuário logado
    private userId = 'ac90a4ed-a332-453d-870a-44867cab2ff0';

    constructor(private mochilasService: MochilasService, private usuarioService: UsuarioService) {}

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
      this.carregarUsoPlano();
    }

    carregarUsoPlano(){
      this.usuarioService
        .getUsoPlano(this.userId)
        .subscribe(data => {
          this.usoPlano = data;
          this.planoLabel = data.plano.toLowerCase();
        });
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
      this.carregarUsoPlano();
    }
}