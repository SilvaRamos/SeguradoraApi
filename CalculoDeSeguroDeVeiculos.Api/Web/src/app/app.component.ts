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
  title = 'Média Aritmética dos Seguros';
  mediaAritmeticaSeguros!:string;

  constructor(private relatorioService : RelatorioService)
  {}


  tabela!:any;

  ngOnInit(): void {
     
    let relatorioSeguros = this.relatorioService.getRelatorioSeguros().subscribe(
      (data:any) => {
      this.mediaAritmeticaSeguros=data["mediaAritmeticaSeguros"];
    });
  }
}
