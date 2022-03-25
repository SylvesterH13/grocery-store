import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { Product } from "src/models/product";

@Injectable()
export class ProductService {

    readonly productEndpoint: string = '/Product'

    constructor(private httpClient : HttpClient) {}

    get(name: string = '', description: string = '', category: string = '', rating?: number, price?: number, orderType: string = '', orderProperty: string = '', )
        : Observable<Array<Product>> {

        var queryParms = new HttpParams()
            .set('name', name)
            .set('description', description)
            .set('category', category)
            .set('orderType', orderType)
            .set('orderProperty', orderProperty);

        if (rating) {
            queryParms = queryParms.set('rating', rating);
        }

        if (price) {
            queryParms = queryParms.set('price', price);
        }

        return this.httpClient.get<Array<Product>>(environment.apiBaseUrl + this.productEndpoint, {
            params: queryParms
        });
    }
}