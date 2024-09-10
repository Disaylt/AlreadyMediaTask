import { Component, OnInit } from '@angular/core';
import {MatTableModule} from '@angular/material/table';
import { IAsteroid } from './models/asteroid.model';
import { AsteroidsService } from '../../services/asteroids.service';
import { ActivatedRoute, Router } from '@angular/router';
import { QueryParamContract } from '../../constants/query-param-contracts';
import { AsteroidSortedType } from '../panel/shared/asteroid-sorted.enums';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-table',
  standalone: true,
  imports: [MatTableModule, CommonModule],
  templateUrl: './table.component.html',
  styleUrl: './table.component.scss'
})
export class TableComponent implements OnInit {
  displayedColumns: string[] = ['year', 'totalMasss', 'quantity'];
  asteroids : IAsteroid[] = [];
  showError : boolean = false;

  constructor(private asteroidService : AsteroidsService, 
    private activateRoute: ActivatedRoute, 
    private router: Router){}

  ngOnInit(): void {
    this.activateRoute.queryParams.subscribe({
      next : data => {
        const sortBy = data[QueryParamContract.sortBy] as AsteroidSortedType;
        const asDesc = data[QueryParamContract.asDesc];
        const minYear = data[QueryParamContract.minYear];
        const maxYear = data[QueryParamContract.maxYear];
        const classType = data[QueryParamContract.classType];
        const nameValue = data[QueryParamContract.nameValue];
        if(sortBy && asDesc){
          this.loadTeble(minYear, maxYear, classType, nameValue, asDesc, sortBy);
        }
      }
    })
  }

  private loadTeble(filterMinYear : string | null, 
    filterMaxYear : string | null,
    classType : string | null,
    namePart : string | null,
    sortAsDesc : boolean | string,
    sort : AsteroidSortedType){
    this.asteroids = [];
    this.asteroidService.getByYearGroup(filterMinYear, filterMaxYear, classType, namePart, sortAsDesc, sort)
    .subscribe({
      next : result => {
        this.asteroids = result;
        this.showError = false;
      },
      error : () => {
        this.showError = true;
      }
    })
  }
}
