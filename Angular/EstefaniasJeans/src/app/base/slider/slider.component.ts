import { Component, Input, OnInit } from "@angular/core";
import { Slider } from "../models/slider";
@Component({
    selector:"app-slider",
    templateUrl:"slider.component.html"
})
export class SliderComponent implements OnInit{
    @Input() images: string[] = [];
    @Input() slider!: Slider;
    constructor() {
    }
    ngOnInit(): void {
    }
}