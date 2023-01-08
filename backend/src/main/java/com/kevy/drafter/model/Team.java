package com.kevy.drafter.model;

import java.util.Set;

import jakarta.persistence.*;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;


@Getter
@Setter
@Entity
@NoArgsConstructor
@Table(name = "TEAMS")
public class Team {
	
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Long id;
	
	private String name;
	
	private Long image;
	
	@OneToMany(fetch = FetchType.EAGER, cascade = CascadeType.ALL)
	private Set<Player> players;
	
	public Team(String name) {
		
		this.name = name;
	}
	
	@Override public String toString(){
		
		return new String("Player: " + name);
	}

}
