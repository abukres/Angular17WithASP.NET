import {
  Component, OnInit, NgModule
} from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  DxButtonModule,
  DxDropDownButtonModule,
  DxTabPanelModule,
  DxValidationGroupModule,
  DxScrollViewModule,
} from 'devextreme-angular';
import {
  CardActivitiesModule,
  CardNotesModule,
  CardMessagesModule,
  StatusIndicatorModule,
} from '../../components';
import { Task } from '../../types/task';
import { DataService } from '../../services';
import { TaskFormModule } from '../../components/library/task-form/task-form.component';
import { DxToolbarModule } from 'devextreme-angular/ui/toolbar';

@Component({
  templateUrl: './planning-task-details.component.html',
  styleUrls: ['./planning-task-details.component.scss'],
  providers: [DataService],
})
export class PlanningTaskDetailsComponent implements OnInit {
  task: Task;

  taskId = 1;

  taskName = 'Loading...';

  isLoading = false;

  constructor(private service: DataService) {
  }

  loadData = () => {
    this.service.getTask(this.taskId).subscribe((data) => {
      this.task = data;
      this.taskName = data.text;
      this.isLoading = false;
    });
  };

  ngOnInit(): void {
    this.loadData();
  }

  refresh = () => {
    this.isLoading = true;
    this.loadData();
  }
}

@NgModule({
  imports: [
    DxButtonModule,
    DxDropDownButtonModule,
    DxTabPanelModule,
    DxValidationGroupModule,
    DxToolbarModule,

    CardActivitiesModule,
    CardNotesModule,
    CardMessagesModule,
    TaskFormModule,
    StatusIndicatorModule,
    DxScrollViewModule,
    CommonModule,
  ],
  providers: [],
  exports: [],
  declarations: [PlanningTaskDetailsComponent],
})
export class PlanningTaskDetailsModule { }
