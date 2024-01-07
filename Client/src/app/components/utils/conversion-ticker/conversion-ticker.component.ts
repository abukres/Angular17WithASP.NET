import {
  Component, NgModule,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { TickerCardModule } from '../../library/ticker-card/ticker-card.component';

@Component({
  selector: 'conversion-ticker',
  templateUrl: 'conversion-ticker.component.html',
})

export class ConversionTickerComponent {
}

@NgModule({
  imports: [
    CommonModule,
    TickerCardModule,
  ],
  declarations: [ConversionTickerComponent],
  exports: [ConversionTickerComponent],
})
export class ConversionTickerModule { }
