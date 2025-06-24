import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { MatTableModule } from '@angular/material/table';
import { RaceService } from '../../../shared/services/race.service';

@Component({
  selector: 'app-race-list',
  standalone: true,
  imports: [CommonModule, RouterModule, MatTableModule],
  templateUrl: './race-list.component.html',
  styleUrls: ['./race-list.component.scss']
})
export class RaceListComponent implements OnInit {
  displayedColumns = ['horse', 'jockey', 'finishingPosition'];
  raceResults: any[] = [];

  constructor(private http: HttpClient, private raceService: RaceService) {}

  ngOnInit(): void {
    this.raceService.getAllRaces().subscribe(data => {
      console.log('API data received:', data);
      this.raceResults = data;
    });
  }
}