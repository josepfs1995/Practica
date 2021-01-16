import { Component } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { ObtenerPedido } from "../model/ObtenerPedido";
import { PedidoDetalle } from "../model/PedidoDetalle";
import { PedidoService } from "../services/pedido.service";

@Component({
  template: 'app-detalle',
  templateUrl:'detalle.component.html'
})
export class DetalleComponent{
    public pedido: ObtenerPedido | any = {
      Mercaderia: {
        Nombre: '',
        MercaderiaFoto: []
      }
    };
    public cantidadTotal = 0;
    public id_Pedido: string = '';
    public cargando: boolean = true;
    public tieneError: boolean = false;
    public errors:string[] = [];
    constructor(private pedidoService: PedidoService,
                private router: ActivatedRoute) {
    }
    ngOnInit(): void {
        this.router.params.subscribe(x=>{
          this.id_Pedido = x["id"];
          this.obtenerPedidos();
        })
    }
    obtenerPedidos():void{
      this.pedidoService.getById(this.id_Pedido).subscribe(
        result=>{this.procesarResultado(result)},
        error => {this.procesarError(error)}
      )
    }
    procesarResultado(success:any):void{
      this.pedido = success;
      this.contarPrendas();
      this.cargando = false;
    }
    procesarError(fail:any):void{
      this.errors = [];
      this.cargando = false;
      this.tieneError = true;
      fail.error.Errors.forEach((error:string) => {
        this.errors.push(error);
        console.log(this.errors);
      });

    }
    contarPrendas():void{
      this.cantidadTotal = 0;
      this.pedido.PedidoDetalle.forEach((pedidoDetalle:PedidoDetalle) => {
        this.cantidadTotal += pedidoDetalle.Cantidad;
      });
    }
}