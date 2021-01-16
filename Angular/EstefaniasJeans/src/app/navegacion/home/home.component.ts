import { Component } from "@angular/core";

@Component({
    selector: "app-home",
    templateUrl: "home.component.html"
})
export class HomeComponent{
    public images: string[] = [
        "assets/img/banner/1.png",
        "assets/img/banner/2.png",
        "assets/img/banner/1.png",
        "assets/img/banner/2.png"
    ]
}