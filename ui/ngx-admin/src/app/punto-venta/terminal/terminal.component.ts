import { PositionModel } from './../../pages/maps/search-map/entity/position.model';
import { Component, OnInit } from '@angular/core';
import { TerminalServices } from '../services/terminal-services';
import { first } from 'rxjs/operators';

@Component({
  selector: 'ngx-terminal',
  templateUrl: './terminal.component.html',
  styleUrls: ['./terminal.component.scss']
})
export class TerminalComponent implements OnInit {

  constructor(private api: TerminalServices,) { }

  ngOnInit(): void {
    this.api.GetConfiguracion().pipe(first())
    .subscribe( conf => {
      console.log(conf);
    }, (e) => {}, ()=>{});
  }

}
