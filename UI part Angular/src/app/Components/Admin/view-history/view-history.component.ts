import { RequestServicesService } from 'src/app/Core/RequestOperations/CrudOperations/request-services.service';

import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';

import { formatDate, formatNumber } from '@angular/common';
import { CheckboxSelectionCallbackParams, ValueFormatterParams } from 'ag-grid-community';

@Component({
  selector: 'app-view-history',
  templateUrl: './view-history.component.html',
  styleUrls: ['./view-history.component.css'],
})
export class ViewHistoryComponent implements OnInit {
  detailedRequest: any;
   searchvalue:any;
   private gridApi:any;
   colDefs:any;
   private gridColumnApi:any;


  adminId  = localStorage.getItem('adminId');

  constructor(private requestDetails: RequestServicesService) {}

    status:any[]=[];



  rowData: any;
  ngOnInit(): void {
    this.colDefs = [
      {
        headerName: 'reqId',
        field: 'reqId',
        filter: 'agNumberColumnFilter',
        columnGroupShow: 'open',
        resizable: true,
        sortable: true,
        animateRows: true,
        rowDrag: true


      },
      { headerName: 'name', field: 'name', sortable: true},
      { headerName: 'purpose', field: 'purpose' },
      { headerName: 'description', field: 'description' },
      {
        headerName: 'estimatedAmount',
        field: 'estimatedAmount',
        filter: 'agSetColumnFilter',
        filterParams: {
          applyMiniFilterWhileTyping: true,
        }
      },
      { headerName: 'statusName' ,field:'statusName', filter: true },
      {
        headerName: 'comments',
        field: 'comments',
        filter: 'agDateColumnFilter',
        editable: true,
        filterParams: {
          buttons: ['reset', 'apply'],
          debounceMs: 200,
        },


      }
    ];






  }

  onGridReady(params:any){
    this.gridApi=params.api;
    this.gridColumnApi=params.api;

    this.requestDetails.getRequests().subscribe(res=>{
     params.api.setRowData(res.filter((item:any)=>item.userId==this.adminId || item.managerId==this.adminId));

    });
  }

  quickSerach(){
    this.gridApi.setQuickFilter(this.searchvalue);
  }

}
