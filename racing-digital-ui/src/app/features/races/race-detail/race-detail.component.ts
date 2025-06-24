import { Component, Input, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { RaceService } from '../../../services/race.service';
import { NoteDialogComponent } from '../../../shared/note-dialog/note-dialog.component';


@Component({
  selector: 'app-race-detail',
  templateUrl: './race-detail.component.html',
  styleUrls: ['./race-detail.component.scss']
})
export class RaceDetailComponent implements OnInit {
  @Input() race: any;

  constructor(private dialog: MatDialog, private raceService: RaceService) {}

  ngOnInit(): void {}

  editNote(): void {
    const dialogRef = this.dialog.open(NoteDialogComponent, {
      width: '400px',
      data: {
        currentNote: this.race.notes || '',
        raceId: this.race.id
      }
    });

    dialogRef.afterClosed().subscribe((result: string) => {
      if (result !== undefined) {
        this.raceService.updateNote(this.race.id, result).subscribe(() => {
          this.race.notes = result;
        });
      }
    });
  }
}