import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MochilaCard } from '../../models/mochilas-card.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-mochila-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './mochila-card.html',
  styleUrls: ['./mochila-card.scss']
})
export class MochilaCardComponent {
  @Input() card!: MochilaCard;

  constructor(private router: Router) {}

  abrirMochila(){
    this.router.navigate([
      '/mochilas',
      this.card.id,
      'questoes'
    ]);
  }
}
