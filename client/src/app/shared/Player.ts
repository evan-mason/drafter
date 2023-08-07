import { FantasyTeamDto } from './FantasyTeamDto';

type FantasyTeam = FantasyTeamDto
export interface Player {
    id: number
    rank: number
    name: string
    position: string
    age: number
    gamesPL: number
    gamesStarted: number
    minutes: number
    fgm: number
    fga: number
    fgp: number
    threePM: number
    threePA: number
    threePP: number
    twoPM: number
    twoPA: number
    twoPP: number
    freeThrowPG: number
    freeThrowPA: number
    freeThrowPP: number
    orb: number
    drb: number
    trb: number
    ast: number
    stl: number
    blk: number
    tov: number
    nbaTeam: string
    points: number
    fantasyTeam: FantasyTeam
    draftTime: string
    draftPosition: number
    pointsTotal: number
    minutesTotal: number
    fgmTotal: number
    fgaTotal: number
    threePMTotal: number
    threePATotal: number
    twoPMTotal: number
    twoPATotal: number
    freeThrowTotal: number
    freeThrowPATotal: number
    orbTotal: number
    drbTotal: number
    trbTotal: number
    astTotal: number
    stlTotal: number
    blkTotal: number
    tovTotal: number
    fantasyPointsAverage: number
    fantasyPointsTotal: number
    playerPictureId: string
}