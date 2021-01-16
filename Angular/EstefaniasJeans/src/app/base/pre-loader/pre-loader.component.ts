import { AfterViewInit, Component, ElementRef, ViewChild } from "@angular/core";

@Component({
    selector: "app-pre-loader",
    template: `<div #preloader class="preloader" id="preloader">
                <div class="preloader-inner">
                    <div class="spinner">
                        <div class="dot1"></div>
                        <div class="dot2"></div>
                    </div>
                </div>
            </div>`
})
export class PreLoaderComponent implements AfterViewInit {
    @ViewChild("preloader", {static: false}) preloader !: ElementRef;
    title = 'EstefaniasJeans';

    ngAfterViewInit(): void {
        this.preloader.nativeElement.style.display = "none";
    }
}