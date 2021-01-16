import { Component, OnInit } from "@angular/core";
import { Subscription } from "rxjs";
import { TokenService } from "src/app/services/token.service";

@Component({
    selector: "app-menu",
    templateUrl: "menu.component.html"
})
export class MenuComponent implements OnInit{
    public isCollapsed: boolean = false;
    public esAdmin: boolean = false;
    subscription: Subscription;
    constructor(private tokenService:TokenService) {
        this.subscription = this.tokenService.suscribirse().subscribe(resultado=>{
            this.esAdmin = resultado;
        });
    }
    ngOnInit(): void {
        this.isCollapsed = true;
        this.esAdmin = this.tokenService.esAdmin();
    }
}