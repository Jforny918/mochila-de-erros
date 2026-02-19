import { Component } from '@angular/core';
import { QuestaoCardModel } from '../../models/questao-card.model';
import { QuestoesService } from '../../services/questoes.service';
import { ActivatedRoute, Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { QuestaoCard } from '../../components/questao-card/questao-card';
import { CriarQuestaoModal } from '../../components/criar-questao-modal/criar-questao-modal';

@Component({
  selector: 'app-questoes-page',
  imports: [CommonModule, QuestaoCard, CriarQuestaoModal],
  templateUrl: './questoes-page.html',
  styleUrl: './questoes-page.scss',
})
export class QuestoesPage {
  questoes: QuestaoCardModel[] = [];
  carregando = true;

  modalAberto = false;

  mochilaId!: string;
  userId = '3fa85f64-5717-4562-b3fc-2c963f66afa6';

  constructor(
    private route: ActivatedRoute,
    private service: QuestoesService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.mochilaId = this.route.snapshot.paramMap.get('mochilaId')!;
    this.carregarQuestoes();
  }

  carregarQuestoes() {
    this.carregando = true;

    this.service.getCards(this.mochilaId, this.userId).subscribe({
      next: q => {
        this.questoes = q;
        this.carregando = false;
      },
      error: () => {
        this.carregando = false;
      }
    });

  }

  voltar(){
    this.router.navigate(['/mochilas'])
  }

  abrirModal(){
    this.modalAberto = true;
  }

  fecharModal(){
    this.modalAberto = false;
  }
}
