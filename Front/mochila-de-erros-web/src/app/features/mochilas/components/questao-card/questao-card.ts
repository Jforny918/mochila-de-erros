import { Component, Input } from '@angular/core';
import { QuestaoCardModel } from '../../models/questao-card.model';

@Component({
  selector: 'app-questao-card',
  imports: [],
  templateUrl: './questao-card.html',
  styleUrl: './questao-card.scss',
})
export class QuestaoCard {
  @Input() questao!: QuestaoCardModel;
}
