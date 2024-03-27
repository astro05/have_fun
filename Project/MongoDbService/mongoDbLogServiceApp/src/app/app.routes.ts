import { Routes } from '@angular/router';
import { MongoDbLogServiceComponent } from './components/mongoDbLogService/mongoDbLogService.component';

export const routes: Routes = [
    {path:'', component: MongoDbLogServiceComponent},
    {path: 'mongoDbLogService', component: MongoDbLogServiceComponent}
];
