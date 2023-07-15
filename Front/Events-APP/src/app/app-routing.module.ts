import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { EventsComponent } from './components/events/events.component';
import { ProfilesComponent } from './components/profiles/profiles.component';
import { ContactsComponent } from './components/contacts/contacts.component';
import { SpeakersComponent } from './components/speakers/speakers.component';

const routes: Routes = [
  { path: '', component: DashboardComponent},
  { path: 'dashboard', component: DashboardComponent},
  { path: 'eventos', component: EventsComponent},
  { path: 'palestrantes', component: SpeakersComponent},
  { path: 'contatos', component: ContactsComponent},
  { path: 'perfil', component: ProfilesComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
