import { Component, OnInit } from '@angular/core';
import { ISortType } from './models/sort-type.model';
import { ISortValue } from './models/sort-value.model';
import { AsteroidSortedType } from './shared/asteroid-sorted.enums';
import { FormsModule } from '@angular/forms';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatFormFieldModule} from '@angular/material/form-field';
import { CdkMenuTrigger, CdkMenu, CdkMenuItem } from '@angular/cdk/menu';
import {MatButtonModule} from '@angular/material/button';
import {MatIconModule} from '@angular/material/icon';
import { ActivatedRoute, Router } from '@angular/router';
import { QueryParamContract } from '../../constants/query-param-contracts';
import { FilterComponent } from "./components/filter/filter.component";

@Component({
  selector: 'app-panel',
  standalone: true,
  imports: [MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    FormsModule,
    MatButtonModule,
    MatIconModule,
    CdkMenuTrigger, FilterComponent],
  templateUrl: './panel.component.html',
  styleUrl: './panel.component.scss'
})
export class PanelComponent implements OnInit{
  sortedValues : ISortValue[] = [
    {view : "Год", value : AsteroidSortedType.byYear},
    {view : "Количество", value : AsteroidSortedType.byQuantity},
    {view : "Масса", value : AsteroidSortedType.byMass}
  ]
  selectedSortedValues : ISortValue = this.sortedValues[0];

  sortedTypes : ISortType[] = [
    {view : "По возрастанию", asDesc : false},
    {view : "По убыванию", asDesc : true},
  ]
  selectedSortedTypes : ISortType = this.sortedTypes[0];

  constructor(private activateRoute: ActivatedRoute, private router: Router){
    
  }

  ngOnInit(): void {
    const isInitType = this.initSortedType();
    const isInitValue = this.initSortedValue();

    if(isInitType == false || isInitValue == false){
      this.router.navigate([], {
        queryParams: { asDesc : this.selectedSortedTypes.asDesc, sortBy : this.selectedSortedValues.value },
        queryParamsHandling: 'merge',
      })
    }
  }

  updateSortedType(){
    this.router.navigate([], {
      queryParams: { asDesc : this.selectedSortedTypes.asDesc },
      queryParamsHandling: 'merge',
    })
  }

  updateSortedValue(){
    this.router.navigate([], {
      queryParams: { sortBy : this.selectedSortedValues.value },
      queryParamsHandling: 'merge',
    })
  }

  private initSortedValue(){
    const sortBy = this.activateRoute.snapshot.queryParams[QueryParamContract.sortBy] as AsteroidSortedType;
    if(sortBy){
      const sortValue = this.sortedValues.find(x=> x.value == sortBy);

      if(sortValue){
        this.selectedSortedValues = sortValue;
      }

      return true;
    }

    return false;
  }

  private initSortedType(){
    const asDesc = this.activateRoute.snapshot.queryParams[QueryParamContract.asDesc] as string;
    if(asDesc === "true" || asDesc === "false"){
      const sortedType = this.sortedTypes.find(x=> `${x.asDesc}` == asDesc);
      if(sortedType){
        this.selectedSortedTypes = sortedType;
      }

      return true;
    }

    return false;
  }
}
