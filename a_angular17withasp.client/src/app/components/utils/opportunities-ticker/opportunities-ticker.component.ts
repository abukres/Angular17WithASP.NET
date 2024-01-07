import {
  Component, NgModule, Input,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { SalesOrOpportunitiesByCategory } from '../../../types/analytics';
import { TickerCardModule } from '../../library/ticker-card/ticker-card.component';

@Component({
  selector: 'opportunities-ticker',
  templateUrl: 'opportunities-ticker.component.html',
})

export class OpportunitiesTickerComponent {
  @Input() data: SalesOrOpportunitiesByCategory = null;
}

@NgModule({
  imports: [
    CommonModule,
    TickerCardModule,
  ],
  declarations: [OpportunitiesTickerComponent],
  exports: [OpportunitiesTickerComponent],
})
export class OpportunitiesTickerModule { }
