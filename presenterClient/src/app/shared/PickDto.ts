import { FantasyTeamDto } from './FantasyTeamDto';

type FantasyTeam = FantasyTeamDto

export interface PickDto {
    id: number
    pickNumber: number
    pickTakenTime: string
    fantasyTeam: FantasyTeam
}