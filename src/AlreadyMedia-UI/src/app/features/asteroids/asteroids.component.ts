import { Component } from '@angular/core';
import { PanelComponent } from "./components/panel/panel.component";
import { TableComponent } from "./components/table/table.component";

@Component({
  selector: 'app-asteroids',
  standalone: true,
  imports: [PanelComponent, TableComponent],
  templateUrl: './asteroids.component.html',
  styleUrl: './asteroids.component.scss'
})
export class AsteroidsComponent {

}
