import { Routes } from '@angular/router';
import { Home } from './features/home/home';
import { UploadPage } from './features/upload-page/upload-page';

export const routes: Routes = [
    { path: '', component: Home },
    { path: 'upload', component: UploadPage },
];
