import { Component, Input } from '@angular/core';
import { QuestaoCardModel } from '../../models/questao-card.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-questao-card',
  standalone: true,
  imports: [],
  templateUrl: './questao-card.html',
  styleUrl: './questao-card.scss',
})
export class QuestaoCard {
  @Input() questao!: QuestaoCardModel;

  
}
