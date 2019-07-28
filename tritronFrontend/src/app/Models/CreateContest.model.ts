import {Time} from '@angular/common';

export class CreateContestModel {
    Name:string;
    StartDate:Date;
    StartTime:Time;
    EndDate:Date;
    EndTime:Time;
    BackgroundImage:string;
    Description:string;
    AllowedLanguage:[string];
}
