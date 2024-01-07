import {
  Component,
  NgModule,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  DxTextBoxModule,
  DxFormModule,
  DxValidatorModule,
} from 'devextreme-angular';
import {
  FormTextboxModule,
  FormPhotoUploaderModule,
} from '../../../components';
import { newContact } from '../../../types/contact';
import { getSizeQualifier } from '../../../services/screen.service';

@Component({
  selector: 'contact-new-form',
  templateUrl: './contact-new-form.component.html',
  providers: [],
})

export class ContactNewFormComponent {
  newUser = newContact;
  getSizeQualifier = getSizeQualifier;
  constructor() { }

  getNewContactData = ()=> ({ ...this.newUser })
}

@NgModule({
  imports: [
    DxTextBoxModule,
    DxFormModule,
    DxValidatorModule,

    FormTextboxModule,
    FormPhotoUploaderModule,

    CommonModule,
  ],
  declarations: [ContactNewFormComponent],
  exports: [ContactNewFormComponent],
})
export class ContactNewFormModule { }
