package com.kevy.drafter;

import java.util.Collections;
import java.util.stream.Stream;

import org.springframework.boot.CommandLineRunner;
import org.springframework.stereotype.Component;

import com.kevy.drafter.model.PlayerRepository;
import com.kevy.drafter.model.Team;
import com.kevy.drafter.model.TeamRepository;
import com.kevy.drafter.model.Player;

@Component
public class Initialiser implements CommandLineRunner{
	
	private final TeamRepository teamRepository;
	private final PlayerRepository playerRepository;
	
	public Initialiser(TeamRepository repository, PlayerRepository repository2) {
		this.teamRepository = repository;
		this.playerRepository = repository2;
	}
	
	@Override 
	public void run (String...strings) {
		Stream.of("Kades", "KEVS", "FOZ").forEach(name -> teamRepository.save(new Team(name)));
		
		Team kevy = teamRepository.findByName("KEVS");
		
		Stream.of("DeAron Fox", "Dirk", "Lebron").forEach(name -> playerRepository.save(new Player(name)));
		
		Player kobe = Player.builder().name("Kobe").team(kevy).build();
		
		kevy.setPlayers(Collections.singleton(kobe));
		
		teamRepository.save(kevy);
		
		System.out.println("Posting all teams");
		teamRepository.findAll().forEach(System.out::println);
		
		System.out.println("Posting all players");
		playerRepository.findAll().forEach(System.out::println);
		 
	}

}
