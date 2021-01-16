import { Component, OnInit } from "@angular/core";
import { ObtenerPedido } from "../model/ObtenerPedido";
import { PedidoService } from "../services/pedido.service";

@Component({
  selector:"app-component",
  templateUrl:"lista.component.html"
})
export class ListaComponent implements OnInit{
  public cargando:boolean = true;
  public pedidos: ObtenerPedido[] = [];
  constructor(private pedidoService:PedidoService) {
    
  }
  ngOnInit(): void {
    this.pedidoService.get().subscribe(
      success => {this.procesarResultado(success)},
      error => { this.procesarError(error)}
    )
  }
  procesarResultado(success:any){
    this.pedidos = success;
    this.cargando = false;
  }
  procesarError(fail:any){
    
  }
}