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
  mediaAritmeticaSeguros!:string;

  tabela!:any;

  ngOnInit(): void {
     
    let relatorioSeguros = this.relatorioService.getRelatorioSeguros();

    console.log("111111:"+relatorioSeguros);

    // let respostaJson = JSON.parse(resposta);    
    this.mediaAritmeticaSeguros = relatorioSeguros['mediaAritmeticaSeguros'];
  }

  constructor(private relatorioService : RelatorioService)
  {}

}
