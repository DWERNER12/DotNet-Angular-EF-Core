import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventsComponent } from './components/events/events.component';
import { SpeakersComponent } from './components/speakers/speakers.component';
import { NavComponent } from '../shared/nav/nav.component';
import { ContactsComponent } from './components/contacts/contacts.component';
import { ProfilesComponent } from './components/profiles/profiles.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { TitleComponent } from 'src/shared/title/title.component';

import { EventService } from './services/event.service';
import { DateTimeFormatPipe } from './helpers/DateTimeFormat.pipe';

import { CollapseModule } from 'ngx-bootstrap/collapse';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';

import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from 'ngx-spinner';

interface NgxSpinnerConfig {
  type?: string;
}

@NgModule({
  declarations: [			
    AppComponent,
    EventsComponent,
    SpeakersComponent,
    ContactsComponent,
    ProfilesComponent,
    DashboardComponent,
    TitleComponent,
    NavComponent,
    DateTimeFormatPipe
   ],
  imports: [
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    BsDropdownModule.forRoot(),
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 10000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressAnimation: 'decreasing',
      progressBar: true
    }),
    NgxSpinnerModule.forRoot({ type: 'pacman' }),
  ],
  providers: [
    EventService
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule { }
