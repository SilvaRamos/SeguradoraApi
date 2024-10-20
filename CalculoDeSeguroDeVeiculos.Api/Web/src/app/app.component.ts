import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { RelatorioService } from './services/relatorio.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,CommonModule
  ],
  providers: [
    
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  title = 'Calculo DeSeguro De Veiculos, Relatório Média Aritmética dos Seguros';
  tabela!:any;

  ngOnInit(): void {
      this.tabela = this.relatorioService.getRelatorioSeguros();
  }

  constructor(private relatorioService : RelatorioService)
  {}

}
