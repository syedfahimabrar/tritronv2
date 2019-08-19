import {Time} from '@angular/common';

export class CreateContestModel {
    id:string;
    Name:string;
    StartTime:string;
    EndTime:string;
    BackgroundImage:string;
    Description:string;
    AllowedLanguage:[string];
    Problems;
}
