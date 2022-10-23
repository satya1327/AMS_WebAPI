import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { LoadingCellRenderer } from 'ag-grid/dist/lib/rendering/rowComp';

import { RequestServicesService } from 'src/app/Core/RequestOperations/CrudOperations/request-services.service';

@Component({
  selector: 'app-user-view-history',
  templateUrl: './user-view-history.component.html',
  styleUrls: ['./user-view-history.component.css'],
})
export class UserViewHistoryComponent implements OnInit {
  rowData: any;
  detailedRequest: any;
  userId: any = localStorage.getItem('userId');

  searchvalue: any;
  private gridApi: any;
  colDefs: any;
  gridColumnApi: any;

  constructor(private requestDetails: RequestServicesService) {}
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
        rowDrag: true,
      },
      { headerName: 'name', field: 'name', sortable: true },
      { headerName: 'purpose', field: 'purpose' },
      { headerName: 'description', field: 'description' },
      {
        headerName: 'estimatedAmount',
        field: 'estimatedAmount',
        filter: 'agSetColumnFilter',
        filterParams: {
          applyMiniFilterWhileTyping: true,
        },
      },
      { headerName: 'statusName', field: 'statusName', filter: true },
      {
        headerName: 'comments',
        field: 'comments',
        filter: 'agDateColumnFilter',
        editable: true,
        filterParams: {
          buttons: ['reset', 'apply'],
          debounceMs: 200,
        },
      },
    ];
  }

  onGridReady(params: any) {
    this.gridApi = params.api;
    this.gridColumnApi = params.api;

    this.requestDetails.getRequests().subscribe((res) => {
      params.api.setRowData(
        res.filter(
          (item: any) =>
            item.userId == this.userId
        )
      );
    });
  }

  quickSerach() {
    this.gridApi.setQuickFilter(this.searchvalue);
  }
}
