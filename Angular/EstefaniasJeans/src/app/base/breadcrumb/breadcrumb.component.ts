import { Component, Input, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Breadcrumb } from "../models/breadcrumb";

@Component({
  selector:"app-breadcrumb",
  templateUrl:"breadcrumb.component.html"
})
export class BreadcrumbComponent implements OnInit{
  public breadcrumb: Breadcrumb[] = [];
  @Input() titulo:string= "";
  constructor(private route: ActivatedRoute) {
  }
  ngOnInit(): void {
    this.breadcrumb = this.armarBreadcrumb(this.route.root);
  }
  armarBreadcrumb(route:ActivatedRoute, url:string = "", breadcrumbs: Breadcrumb[] = []):Breadcrumb[]{
    let nombre = route.routeConfig && route.routeConfig.data ? route.snapshot.data.breadcrumb : "";
    let path = route.routeConfig && route.routeConfig.data ? route.routeConfig.path : "";
    const lastRoutePart = path?.split("/").pop();
    const isDynamicRoute = lastRoutePart?.startsWith(":");
    if (isDynamicRoute && !!route.snapshot) {
      const paramName = lastRoutePart?.split(":")[1] ?? "";
      path = path?.replace(lastRoutePart ?? "", route.snapshot.params[paramName]);
      nombre = route.snapshot.params[paramName];
    }

    const nextUrl = path ? `${url}/${path}` : url;

    const breadcrumb: Breadcrumb = new Breadcrumb(nombre, nextUrl);

    const newBreadcrumbs = breadcrumb.Nombre
    ? [...breadcrumbs, breadcrumb]
    : [...breadcrumbs];
    if (route.firstChild) {
      return this.armarBreadcrumb(route.firstChild, nextUrl, newBreadcrumbs);
    }
    return newBreadcrumbs;
  }
}