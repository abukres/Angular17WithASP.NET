import {
  Component, OnInit, NgModule,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  DxButtonModule,
  DxDropDownButtonModule,
  DxScrollViewModule,
} from 'devextreme-angular';
import {
  CardActivitiesModule,
  CardNotesModule,
  CardMessagesModule,
} from '../../components';
import { DataService } from '../../services';
import { forkJoin, map } from 'rxjs';
import { Contact } from '../../types/contact';
import { Messages } from '../../types/messages';
import { Notes } from '../../types/notes';
import { Opportunities } from '../../types/opportunities';
import { ContactFormModule } from '../../components/library/contact-form/contact-form.component';
import { ContactCardsModule } from '../../components/utils/contact-cards/contact-cards.component';
import { DxToolbarModule } from 'devextreme-angular/ui/toolbar';

@Component({
  templateUrl: './crm-contact-details.component.html',
  styleUrls: ['./crm-contact-details.component.scss'],
  providers: [DataService],
})
export class CrmContactDetailsComponent implements OnInit {
  contactId = 12;

  contactData: Contact;

  contactNotes: Notes;

  contactMessages: Messages;

  activeOpportunities: Opportunities;

  closedOpportunities: Opportunities;

  contactName = 'Loading...';

  isLoading = false;

  constructor(private service: DataService) {
  }

  ngOnInit(): void {
    this.loadData();
  }

  loadData = () => {
    forkJoin([
      this.service.getContactNotes(this.contactId),
      this.service.getContactMessages(this.contactId),
      this.service.getActiveContactOpportunities(this.contactId),
      this.service.getClosedContactOpportunities(this.contactId),
    ]).pipe(
      map(
        ([
          contactNotes,
          contactMessages,
          activeOpportunities,
          closedOpportunities
        ]) => ({
          contactNotes,
          contactMessages,
          activeOpportunities,
          closedOpportunities
        }))
      ).subscribe(
        (data) => Object.keys(data).forEach((key) => this[key] = data[key])
    );

    this.service.getContact(this.contactId).subscribe((data) => {
      this.contactName = data.name;
      this.contactData = data;
      this.isLoading = false;
    })
  };

  refresh = () => {
    this.isLoading = true;
    this.loadData();
  };
}

@NgModule({
  imports: [
    DxButtonModule,
    DxDropDownButtonModule,
    DxScrollViewModule,
    DxToolbarModule,

    ContactFormModule,
    ContactCardsModule,

    CardActivitiesModule,
    CardNotesModule,
    CardMessagesModule,

    CommonModule,
  ],
  providers: [],
  exports: [],
  declarations: [CrmContactDetailsComponent],
})
export class CrmContactDetailsModule { }
