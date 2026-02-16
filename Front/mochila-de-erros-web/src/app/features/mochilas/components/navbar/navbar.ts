import { Component } from '@angular/core';
import { MochilaCardComponent } from '../mochila-card/mochila-card';
import { CommonModule } from '@angular/common';
import { MochilaCard } from '../../models/mochilas-card.model';

@Component({
  selector: 'app-navbar',
  imports: [MochilaCardComponent, CommonModule],
  templateUrl: './navbar.html',
  styleUrl: './navbar.scss',
})
export class Navbar {
  carregando = true;
  mochilas: MochilaCard[] = [];
}
