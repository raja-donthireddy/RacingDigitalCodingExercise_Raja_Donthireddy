import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

export interface NoteDialogData {
  currentNote: string;
  raceId: number;
}

@Component({
  selector: 'app-note-dialog',
  templateUrl: './note-dialog.component.html',
  styleUrls: ['./note-dialog.component.scss']
})
export class NoteDialogComponent {
  noteForm: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<NoteDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: NoteDialogData,
    private fb: FormBuilder
  ) {
    this.noteForm = this.fb.group({
      note: [data.currentNote || '', [Validators.required, Validators.maxLength(500)]]
    });
  }

  onSave(): void {
    if (this.noteForm.valid) {
      this.dialogRef.close(this.noteForm.value.note);
    }
  }

  onCancel(): void {
    this.dialogRef.close();
  }
}