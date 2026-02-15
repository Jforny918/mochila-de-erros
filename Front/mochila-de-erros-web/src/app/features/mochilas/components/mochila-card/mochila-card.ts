import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MochilaCard } from '../../models/mochilas-card.model';

@Component({
  selector: 'app-mochila-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './mochila-card.html',
  styleUrls: ['./mochila-card.scss']
})
export class MochilaCardComponent {
  @Input({ required: true }) card!: MochilaCard;
}
