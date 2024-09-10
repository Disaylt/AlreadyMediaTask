import {Component, OnInit} from '@angular/core';
import {MatInputModule} from '@angular/material/input';
import {MatFormFieldModule} from '@angular/material/form-field';
import {FormsModule} from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { QueryParamContract } from '../../../../constants/query-param-contracts';

@Component({
  selector: 'app-filter',
  standalone: true,
  imports: [FormsModule, MatFormFieldModule, MatInputModule],
  templateUrl: './filter.component.html',
  styleUrl: './filter.component.scss'
})
export class FilterComponent implements OnInit {
  minYear : string = "";
  maxYear : string = "";
  classType : string = "";
  name : string = "";

  constructor(private activateRoute: ActivatedRoute, private router: Router){
    
  }

  ngOnInit(): void {
    this.minYear = this.activateRoute.snapshot.queryParams[QueryParamContract.minYear];
    this.maxYear = this.activateRoute.snapshot.queryParams[QueryParamContract.maxYear];
    this.classType = this.activateRoute.snapshot.queryParams[QueryParamContract.classType];
    this.name = this.activateRoute.snapshot.queryParams[QueryParamContract.nameValue];
  }

  onInputName(){
    this.router.navigate([], {
      queryParams: { "nameValue" : this.name },
      queryParamsHandling: 'merge',
    })
  }

  onInputMaxYear(){
    this.router.navigate([], {
      queryParams: { "maxYear" : this.maxYear },
      queryParamsHandling: 'merge',
    })
  }

  onInputMinYear(){
    this.router.navigate([], {
      queryParams: { "minYear" : this.minYear },
      queryParamsHandling: 'merge',
    })
  }

  onInputClassType(){
    this.router.navigate([], {
      queryParams: { "classType" : this.classType },
      queryParamsHandling: 'merge',
    })
  }
}
