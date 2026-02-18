import { Component } from '@angular/core';
import { QuestaoCardModel } from '../../models/questao-card.model';
import { QuestoesService } from '../../services/questoes.service';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';
import { QuestaoCard } from '../../components/questao-card/questao-card';

@Component({
  selector: 'app-questoes-page',
  imports: [CommonModule, QuestaoCard],
  templateUrl: './questoes-page.html',
  styleUrl: './questoes-page.scss',
})
export class QuestoesPage {
  questoes: QuestaoCardModel[] = [];
  carregando = true;


  mochilaId!: string;
  userId = '3fa85f64-5717-4562-b3fc-2c963f66afa6';

  constructor(
    private route: ActivatedRoute,
    private service: QuestoesService
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
}
