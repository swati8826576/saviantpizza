import { Component } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { PizzaDetailsViewModel } from '../_models/PizzaDetailsViewModel';


@Component({
  selector: 'pizza',
  templateUrl: './pizza.component.html',
  styleUrls: ['./pizza.component.scss']
})
export class PizzaComponent {
  title = 'CheckList for Parents and Child Structure with Expand/ Collapse';
  data: PizzaDetailsViewModel[]; 
  list: number[]
  myAppUrl: string;
  myApiUrl: string;
  constructor(private http: HttpClient ) {
   
  }

  ngOnInit() {
    this.myAppUrl = environment.appUrl;
      this.myApiUrl = 'Pizza';

     this.http.get<any>(this.myAppUrl + this.myApiUrl)
      .subscribe(
        data => {
          this.data = data;
          
        }
      );
   
  }

  //Click event on parent checkbox  
  parentCheck(parentObj) {
    for (var i = 0; i < parentObj.PizzaDetails.length; i++) {
      parentObj.PizzaDetails[i].isSelected = parentObj.isSelected;
    }
  }

  //Click event on child checkbox  
  childCheck(parentObj, childObj) {


   var headers = {
      headers: new HttpHeaders({
        contentType: 'application/json; charset=utf-8',
        dataType: 'json'
      })
    }
    // this.http.post<any>(this.myAppUrl + this.myApiUrl, { childObj: childObj})
     
      this.myAppUrl = environment.appUrl;
      this.myApiUrl = 'Pizza';

    
    //var viewModel = [];

    //parentObj.isSelected = childObj.every(function (itemChild: any) {
   // childObj.every(function (itemChild: any) {

        

       //return itemChild.isSelected == true;

   // })


   
  }
  PlaceOrder() {
    this.myApiUrl = 'Order';

    var viewModel = this.data;
    this.http.post<boolean>(this.myAppUrl + this.myApiUrl, viewModel)
      .subscribe(data => {

        if (data == true)
        {
          alert("Order Placed Successfully !!")
        }

        else {
          alert("Something went wrong !!")

        }
      });

  }
  //Click event on master select
  //selectUnselectAll(obj) {
  //  obj.isAllSelected = !obj.isAllSelected;
  //  for (var i = 0; i < obj.ParentChildchecklist.length; i++) {
  //    obj.ParentChildchecklist[i].isSelected = obj.isAllSelected;
  //    for (var j = 0; j < obj.ParentChildchecklist[i].PizzaDetails.length; j++) {
  //      obj.ParentChildchecklist[i].PizzaDetails[j].isSelected = obj.isAllSelected;
  //    }
  //  }
  //}

  //Expand/Collapse event on each parent
  expandCollapse(obj) {
    obj.isClosed = !obj.isClosed;
  }

  //Master expand/ collapse event
  expandCollapseAll(obj) {
    for (var i = 0; i < obj.ParentChildchecklist.length; i++) {
      obj.ParentChildchecklist[i].isClosed = !obj.isAllCollapsed;
    }
    obj.isAllCollapsed = !obj.isAllCollapsed;
  }

  //Just to show updated JSON object on view
  stringify(obj) {
    return JSON.stringify(obj);
  }
}
