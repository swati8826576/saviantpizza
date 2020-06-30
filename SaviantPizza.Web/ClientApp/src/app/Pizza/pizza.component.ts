import { Component } from '@angular/core';

@Component({
  selector: 'pizza',
  templateUrl: './pizza.component.html',
  styleUrls: ['./pizza.component.scss']
})
export class PizzaComponent {
  title = 'CheckList for Parents and Child Structure with Expand/ Collapse';
  data: any;

  constructor() {
    this.data = {};
    this.data.isAllSelected = false;
    this.data.isAllCollapsed = false;

    //List object having hierarchy of parents and its children
    this.data.ParentChildchecklist = [
      {
        id: 1, value: 'Dominos', isSelected: false, isClosed: true,
        childList: [
          {
            pizzaId: 1, vendorId: 1, value: 'Margherita ', isSelected: false ,Price : 250 , DiscountedPrice : 150
          },
          {
            id: 2, parent_id: 1, value: 'Farm House', isSelected: false,
          }
        ]
      },
      {
        id: 2, value: 'Pizza Hut', isSelected: false, isClosed: true, childList: [
          {
            id: 1, parent_id: 1, value: 'Cheese n corn', isSelected: false
          },
          {
            id: 2, parent_id: 1, value: 'Chicken sausage', isSelected: false
          }
        ]
      },
      {
        id: 3, value: 'Papa Johns', isSelected: false, isClosed: true,
        childList: [
          {
            id: 1, parent_id: 1, value: 'Farm House', isSelected: false
          },
          {
            id: 2, parent_id: 1, value: 'Margherita', isSelected: false
          }
        ]
      }
    ];
  }

  //Click event on parent checkbox  
  parentCheck(parentObj) {
    for (var i = 0; i < parentObj.childList.length; i++) {
      parentObj.childList[i].isSelected = parentObj.isSelected;
    }
  }

  //Click event on child checkbox  
  childCheck(parentObj, childObj) {
    parentObj.isSelected = childObj.every(function (itemChild: any) {
      return itemChild.isSelected == true;


    })
  }

  //Click event on master select
  selectUnselectAll(obj) {
    obj.isAllSelected = !obj.isAllSelected;
    for (var i = 0; i < obj.ParentChildchecklist.length; i++) {
      obj.ParentChildchecklist[i].isSelected = obj.isAllSelected;
      for (var j = 0; j < obj.ParentChildchecklist[i].childList.length; j++) {
        obj.ParentChildchecklist[i].childList[j].isSelected = obj.isAllSelected;
      }
    }
  }

  //Expand/Collapse event on each parent
  expandCollapse(obj) {
    obj.isClosed = !obj.isClosed;
  }

  //Master expand/ collapse event
  expandCollapseAll(obj) {
    alert("hii")
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
