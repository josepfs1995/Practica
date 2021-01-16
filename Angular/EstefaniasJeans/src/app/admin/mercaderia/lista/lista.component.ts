import { Component, OnInit } from "@angular/core";
import { ToastrService } from "ngx-toastr";
import { Mercaderia } from "../model/Mercaderia";
import { MercaderiaService } from "../services/mercaderia.service";

@Component({
  selector:"app-mercaderia",
  templateUrl: "lista.component.html"
})
export class ListaComponent implements OnInit{
  mercaderias: Mercaderia[] = [];
  constructor(private mercaderiaService: MercaderiaService,
            private toastr: ToastrService) {
    
  }
  ngOnInit(): void {
    this.mercaderiaService.get().subscribe(
      success => {this.procesarResultado(success)}
    )
  }
  procesarResultado(success:any):void{
    this.mercaderias = success;
  }
  eliminarResultado(id:string):void{
    this.mercaderiaService.remove(id).subscribe(
      success => { this.toastr.success("Se elimino correctamente"); }
    )
  }
}