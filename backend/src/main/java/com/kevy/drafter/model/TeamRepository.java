package com.kevy.drafter.model;

import org.springframework.data.jpa.repository.JpaRepository;

public interface TeamRepository extends JpaRepository<Team, Long> {
	
	Team findByName(String name);

}
