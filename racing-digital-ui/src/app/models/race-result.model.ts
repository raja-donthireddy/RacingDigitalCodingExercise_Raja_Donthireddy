export interface RaceResult {
    id: number;
    race: string;
    raceDate: Date;
    raceTime: string; // or Date if you're parsing it as time
    racecourse: string;
    raceDistance: number;
    jockey: string;
    trainer: string;
    horse: string;
    finishingPosition: number;
    distanceBeaten?: number;
    timeBeaten?: number;
    notes?: string;
  }
  