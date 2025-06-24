import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { MatCardModule } from '@angular/material/card';
import { FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { Race } from '../../../shared/models/race.model';
import { RaceService } from '../../../shared/services/race.service';

@Component({
  selector: 'app-race-detail',
  standalone: true,
  imports: [CommonModule, MatCardModule, FormsModule, MatFormFieldModule, MatInputModule, MatButtonModule, MatSnackBarModule],
  templateUrl: './race-detail.component.html',
  styleUrls: ['./race-detail.component.scss']
})
export class RaceDetailComponent implements OnInit {
  raceId: string | null = null;
  notes: string = '';
  race: Race | null=null;

  constructor(private route: ActivatedRoute, private http: HttpClient, private raceService: RaceService, private snackBar: MatSnackBar) { }

  ngOnInit(): void {
    this.raceId = this.route.snapshot.paramMap.get('id');
    if (this.raceId) {
      this.raceService.getRace(this.raceId!).subscribe(data => {
        this.race = data;
        this.notes = data.notes || '';
      });
    }
  }
  
  saveNotes(): void {
  if (!this.notes.trim()) {
    this.snackBar.open('Please enter a note before saving 📝', 'Close', {
      duration: 3000
    });
    return;
  }

  if (!this.raceId) return;

  this.raceService.updateNote(this.raceId, this.notes).subscribe(() => {
    this.snackBar.open('Notes saved ✅', 'Close', {
      duration: 3000
    });
  });
}

}