import { Routes } from '@angular/router';
import { AsteroidsComponent } from './features/asteroids/asteroids.component';

export const routes: Routes = [
    {
        path : "asteroids",
        component : AsteroidsComponent
    },
    {
        path:"**", 
        redirectTo:"/asteroids"
    }
];
