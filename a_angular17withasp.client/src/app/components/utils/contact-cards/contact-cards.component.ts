import {
  Component, NgModule, Input,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  DxButtonModule,
  DxTabPanelModule,
  DxDataGridModule,
} from 'devextreme-angular';
import {
  CardNotesModule,
  CardMessagesModule,
  CardActivitiesModule,
  CardOpportunitiesModule,
  CardTasksModule,
} from '../../../components';
import { Activity } from '../../../types/activities';
import { Messages } from '../../../types/messages';
import { Notes } from '../../../types/notes';
import { Opportunities } from '../../../types/opportunities';
import { Task } from '../../../types/task';

@Component({
  selector: 'contact-cards',
  templateUrl: './contact-cards.component.html',
  styleUrls: ['./contact-cards.component.scss'],
})
export class ContactCardsComponent {
    @Input() tasks: Task[];

    @Input() activities: Activity[];

    @Input() activeOpportunities: Opportunities;

    @Input() closedOpportunities: Opportunities;

    @Input() notes: Notes;

    @Input() messages: Messages;

    @Input() contactName: string;

    @Input() isLoading: boolean;
}

@NgModule({
  imports: [
    DxButtonModule,
    DxTabPanelModule,
    DxDataGridModule,

    CardNotesModule,
    CardMessagesModule,
    CardActivitiesModule,
    CardOpportunitiesModule,
    CardTasksModule,

    CommonModule,
  ],
  providers: [],
  exports: [ContactCardsComponent],
  declarations: [ContactCardsComponent],
})
export class ContactCardsModule { }
