import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IAsteroid } from '../components/table/models/asteroid.model';
import { AsteroidSortedType } from '../components/panel/shared/asteroid-sorted.enums';

@Injectable({
  providedIn: 'root'
})
export class AsteroidsService{
    constructor(private httpClient : HttpClient) { }

    getByYearGroup(filterMinYear : string | null, 
        filterMaxYear : string | null,
        classType : string | null,
        namePart : string | null,
        sortAsDesc : boolean | string,
        sort : AsteroidSortedType){
        let path = `api/asteroids/group/year?sortAsDesc=${sortAsDesc}&sort=${sort}&`;

        if(filterMinYear){
          path += `filterMinYear=${filterMinYear}&`;
        }
        if(filterMaxYear){
          path += `filterMaxYear=${filterMaxYear}&`;
        }
        if(classType){
          path += `classType=${classType}&`;
        }
        if(namePart){
          path += `namePart=${namePart}&`
        }

        return this.httpClient.get<IAsteroid[]>(path);
    }
}